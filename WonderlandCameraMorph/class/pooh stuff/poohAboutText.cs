poohAboutText
	| about url font pattern start end |
	about _ '     Pooh

This software is based on the work of Takeo Igarashi, Satoshi Matsuoka and Hidehiko Tanaka, which is described in "Teddy: A Sketching Interface for 3D Freeform Design".

To play around with Pooh just open a Wonderland and bring up the halos on the CameraMorph. Click on the Pooh halo and start drawing an outline. After that you can bring up the halos on the generated object and click on the Paint halo to draw on the surface. (Or have a look at this tape)' asText.


	font _ TextFontChange new fontNumber: 3.

	pattern _ 'Pooh'.
	start _ about string findString: pattern.
	end _ start + pattern size.
	about addAttribute: font from: start to: end.
	about makeBoldFrom: start to: end.

	pattern _ 'Takeo Igarashi'.
	start _ about string findString: pattern.
	end _ start + pattern size.
	url _ TextURL new url: 'http://www.mtl.t.u-tokyo.ac.jp/~takeo/teddy/teddy.htm'.
	about addAttribute: url from: start to: end.

	pattern _ 'open a Wonderland'.
	start _ about string findString: pattern.
	end _ start + pattern size.
	url _ TextDoIt new evalString: 'Wonderland new'.
	about addAttribute: url from: start to: end.

	pattern _ 'tape'.
	start _ about string findString: pattern.
	end _ start + pattern size.
	url _ TextDoIt new evalString: 'WonderlandCameraMorph poohPlayTape'.
	about addAttribute: url from: start to: end.

	^ about