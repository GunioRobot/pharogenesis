absoluteSquared8Dot24: value
	"Compute the squared value of a 8.24 number with 0.0 <= value < 1.0,
	e.g., compute (value * value) bitShift: -24"
	| halfWord1 halfWord2 result |
	(value >= 0 and:[value < 16r1000000]) ifFalse:[^self error:'Value out of range'].
	halfWord1 _ value bitAnd: 16rFFFF.
	halfWord2 _ (value bitShift: -16) bitAnd: 255.

	result _ (halfWord1 * halfWord1) bitShift: -16. "We don't need the lower 16bits at all"
	result _ result + ((halfWord1 * halfWord2) * 2).
	result _ result + ((halfWord2 * halfWord2) bitShift: 16).
	"word1 _ halfWord1 * halfWord1.
	word2 _ (halfWord2 * halfWord1) + (word1 bitShift: -16).
	word1 _ word1 bitAnd: 16rFFFF.
	word2 _ word2 + (halfWord1 * halfWord2).
	word2 _ word2 + ((halfWord2 * halfWord2) bitShift: 16)."

	^result bitShift: -8