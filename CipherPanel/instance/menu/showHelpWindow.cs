showHelpWindow
	((StringHolder new contents: 'The Cipher Panel displays an encrypted message.  The encryption is a simple substitution code;  each letter of the alphabet has been changed to a different one.

You can solve the cipher by clicking above any letter in the message, and typing the letter you think it should be.  The Cipher Panel automatically makes the same substitution anywhere else that letter occurs in the encoded message.

If you are having trouble, you can use the command menu to ''show cipher hints''.  That will display how many of each letter occurs, which is often a help in solving ciphers.' translated)
		embeddedInMorphicWindowLabeled: 'About the Cipher Panel' translated)
		setWindowColor: (Color
				r: 1.0
				g: 0.6
				b: 0.0);
		 openInWorld: self world extent: 389 @ 209