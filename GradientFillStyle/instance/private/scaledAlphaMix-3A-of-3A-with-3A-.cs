scaledAlphaMix: theta of: lastWord with: nextWord
	"Open-coded version of alpha mixing two 32bit pixel words and returning the scaled pixel value."
	| word0 word1 a0 a1 alpha v0 v1 vv value |
	word0 _ lastWord.
	word1 _ nextWord.
	"note: extract alpha first so we'll be in SmallInteger range afterwards"
	a0 _ word0 bitShift: -24. a1 _ word1 bitShift: -24.
	alpha _ a0 + (a1 - a0 * theta) truncated.
	"Now make word0 and word1 SmallIntegers"
	word0 _ word0 bitAnd: 16rFFFFFF. word1 _ word1 bitAnd: 16rFFFFFF.
	"Compute first component value"
	v0 _ (word0 bitAnd: 255). v1 _ (word1 bitAnd: 255).
	vv _ (v0 + (v1 - v0 * theta) truncated) * alpha // 255.
	value _ vv.
	"Compute second component value"
	v0 _ ((word0 bitShift: -8) bitAnd: 255). v1 _ ((word1 bitShift: -8) bitAnd: 255).
	vv _ (v0 + (v1 - v0 * theta) truncated) * alpha // 255.
	value _ value bitOr: (vv bitShift: 8).
	"Compute third component value"
	v0 _ ((word0 bitShift: -16) bitAnd: 255). v1 _ ((word1 bitShift: -16) bitAnd: 255).
	vv _ (v0 + (v1 - v0 * theta) truncated) * alpha // 255.
	value _ value bitOr: (vv bitShift: 16).
	"Return result"
	^value bitOr: (alpha bitShift: 24)