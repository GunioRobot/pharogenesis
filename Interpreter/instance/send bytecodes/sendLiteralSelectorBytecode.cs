sendLiteralSelectorBytecode
	"Can use any of the first 16 literals for the selector and pass up to 2 arguments."

	messageSelector _ self literal: (currentBytecode bitAnd: 16rF).
	argumentCount _ ((currentBytecode >> 4) bitAnd: 3) - 1.
	self normalSend.
"
Note - if you ever want to try inlining these, the following will produce the code to paste into interp.c -- I found it actually slowed things down (cache size effect?).
String streamContents:
	[:s | 208 to: 255 do:
		[:i | s tab; tab; nextPutAll: 'case ', i printString, ':'; cr.
		s tab; tab; tab; nextPutAll: 'messageSelector = longAt(((char *) method) + 4 + ';
			print: ((i bitAnd: 15) + 1) << 2; nextPutAll: ');'; cr.
		s tab; tab; tab; nextPutAll: 'argumentCount = ';
			print: (i >> 4 bitAnd: 3) - 1; nextPutAll: ';'; cr.
		s tab; tab; tab; nextPutAll: 'goto commonSend;'; cr.
		s tab; tab; tab; nextPutAll: 'break;'; cr; cr]]
"