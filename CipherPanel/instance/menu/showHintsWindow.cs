showHintsWindow
	((StringHolder new contents: 'Most bodies of english text follow a general pattern of letter usage.  The following are the most common letters, in approximate order of frequency:
	E  T  A  O  N  I  R  S  H
The following are the most common digraphs:
	EN  ER  RE  NT  TH  ON  IN

The message you are trying to decode has the following specific statistics:' translated , self cipherStats , '

Good luck!' translated)
		embeddedInMorphicWindowLabeled: 'Some Useful Statistics' translated)
		setWindowColor: (Color
				r: 1.0
				g: 0.6
				b: 0.0);
		 openInWorld: self world extent: 318 @ 326