stringAt: stringOffset length: byteLength multiByte: aBoolean

	| string index stringLength |
	aBoolean ifFalse:[
		stringLength _ byteLength.
		string _ String new: stringLength.
		index _ stringOffset.
		1 to: stringLength do:[:i|
			string at: i put: (Character value: (fontData byteAt: index + i - 1))].
		^string
	] ifTrue:[
		stringLength _ byteLength // 2.
		string _ String new: stringLength.
		index _ stringOffset.
		1 to: stringLength do:[:i|
			string at: i put: (Character value: (fontData byteAt: index + 1)).
			index _ index + 2].
		^string]