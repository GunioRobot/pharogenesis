rangesForKorean

	| basics etc |
	basics _ {
		Array with: 16rA1 with: 16rFF
	}.
	etc _ {
		Array with: 16r100 with: 16r17F. "extended latin"
		Array with: 16r370 with: 16r3FF. "greek"
		Array with: 16r400 with: 16r52F. "cyrillic"
		Array with: 16r2000 with: 16r206F. "general punctuation"
		Array with: 16r2100 with: 16r214F. "letterlike"
		Array with: 16r2150 with: 16r218F. "number form"
		Array with: 16r2190 with: 16r21FF. "arrows"
		Array with: 16r2200 with: 16r22FF. "math operators"
		Array with: 16r2300 with: 16r23FF. "misc tech"
		Array with: 16r2460 with: 16r24FF. "enclosed alnum"
		Array with: 16r2500 with: 16r257F. "box drawing"
		Array with: 16r2580 with: 16r259F. "box elem"
		Array with: 16r25A0 with: 16r25FF. "geometric shapes"
		Array with: 16r2600 with: 16r26FF. "misc symbols"
		Array with: 16r3000 with: 16r303F. "cjk symbols"
		Array with: 16r3040 with: 16r309F. "hiragana"
		Array with: 16r30A0 with: 16r30FF. "katakana"
		Array with: 16r3190 with: 16r319F. "kanbun"
		Array with: 16r31F0 with: 16r31FF. "katakana extension"
		Array with: 16r3200 with: 16r32FF. "enclosed CJK"
		Array with: 16r3300 with: 16r33FF. "CJK compatibility"
		Array with: 16r4E00 with: 16r9FAF. "CJK ideograph"
		Array with: 16rAC00 with: 16rD7AF. "Hangul Syllables"
		Array with: 16rF900 with: 16rFAFF. "CJK compatiblity ideograph"
		Array with: 16rFF00 with: 16rFFEF. "half and full"
	}.

	^ basics, etc.
