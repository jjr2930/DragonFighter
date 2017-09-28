using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;
using System.Text;

public static class CryptoPlayerPref
{
	/// <summary>
	/// how to hide this key
	/// </summary>
    public static byte[] cryptoKey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };
    public static byte[] cryptoIV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };

	static AesManaged aesManaged = null;
	static ICryptoTransform encryptor = null;
	static ICryptoTransform decryptor = null;

	static CryptoPlayerPref()
	{
		aesManaged = new AesManaged();
		aesManaged.Key = cryptoKey;
		aesManaged.IV = cryptoIV;
		aesManaged.Mode = CipherMode.ECB;
		aesManaged.Padding = PaddingMode.PKCS7;

		encryptor = aesManaged.CreateEncryptor();
		decryptor = aesManaged.CreateDecryptor();
	}

	#region Get
	public static int GetInt(string key)
	{
		string plainText = GetPlainText( key );
		int plainInt = 0;
		if (int.TryParse( plainText, out plainInt ))
		{
			return plainInt;
		}

		Debug.LogErrorFormat( "CryptoPlayerPref.GetInt => key : {0} not founded or not parse", key );
		return int.MinValue;
	}

	public static float GetFloat(string key)
	{
		string plainText = GetPlainText( key );
		float plainFloat = 0;
		if (float.TryParse( plainText, out plainFloat ))
		{
			return plainFloat;
		}

		Debug.LogErrorFormat( "CryptoPlayerPref.Getfloat => key : {0} not founded or not parse", key );
		return float.MinValue;
	}


	public static string GetString(string key)
	{
		string plainText = GetPlainText( key );
		return plainText;
	}


	private static string GetPlainText(string key)
	{
		string cypherText = PlayerPrefs.GetString( key );
		byte[] cypherBytes = Encoding.UTF8.GetBytes( cypherText );
		byte[] plainBytes = Decrypt( cypherBytes );
		string plainText = Encoding.UTF8.GetString( plainBytes );
		return plainText;
	}
	#endregion
	#region Set

	public static void SetInt(string key, int value)
	{
		byte[] cipherBytes = Encrypt( value );
		string cipherText = Encoding.UTF8.GetString( cipherBytes );

		PlayerPrefs.SetString( key, cipherText );
	}

	public static void SetFloat(string key, float value)
	{
		byte[] cipherBytes = Encrypt( value );
		string cipherText = Encoding.UTF8.GetString( cipherBytes );

		PlayerPrefs.SetString( key, cipherText );
	}

	public static void SetString(string key, string value)
	{
		byte[] cipherBytes = Encrypt( value );
		string cipherText = Encoding.UTF8.GetString( cipherBytes );

		PlayerPrefs.SetString( key, cipherText );
	}



	#endregion

	#region Other PlayerPref methods
	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static bool HasKey(string key)
	{
		return PlayerPrefs.HasKey( key );
	}

	public static void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey( key );
	}

	public static void DeleteAll(string key)
	{
		PlayerPrefs.DeleteAll();
	}
	#endregion

	#region Overloaded Ecrypt Method    

	static byte[] Encrypt(float plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(ulong plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(uint plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(ushort plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(long plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(double plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(short plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(char plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(bool plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(int plainNumber)
	{
		byte[] bytes = BitConverter.GetBytes( plainNumber );
		return Encrypt( bytes );
	}

	static byte[] Encrypt(string plainText)
	{
		byte[] bytes = UTF8Encoding.UTF8.GetBytes( plainText.ToCharArray() );
		return Encrypt( bytes );
	}
	#endregion

	#region base encrypt and decrypt method
	public static byte[] Encrypt(byte[] plainBytess)
	{
		byte[] cypherBytes = encryptor.TransformFinalBlock( plainBytess, 0, plainBytess.Length );
		return cypherBytes;
	}

	public static byte[] Decrypt(byte[] cypherBytes)
	{
		byte[] plainBytes = decryptor.TransformFinalBlock( cypherBytes, 0, cypherBytes.Length );
		return plainBytes;
	}
	#endregion
}