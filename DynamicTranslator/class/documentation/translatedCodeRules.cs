translatedCodeRules
"
The layout of translated code must adhere to one vary important rule: even-numbered extension words (where the opcode is word 0 and the extension words are numbered 1, 2, 3, ...) must *NEVER* contain a SmallInteger literal.

This rule is necessary because the translator encodes opcodes as SmallIntegers, and then checks their values when performing rewrites on previously translated opcodes.  All bets are off should a SmallInteger literal in an extension word ever be mistaken for an opcode, and subsequently be replaced with a different (SmallInteger) opcode because a rewrite rule was triggered.

Note: some of the extended opcodes do not implement this policy yet, so we're currently living dangerously.  I am hoping that this won't be an immediate problem since the integers that appear in extension word 2 for these opcodes are all indices between 0 and 255, which should not clash with the opcodes (which are all code addresses in the compiled VM implementation, guaranteed [on every architecture that I know about] to have values much higher than 255).  (The simulator is another matter, since it uses SmallIntegers between 1 and OpcodeTableSize to represent translated opcodes.  Yikes!)
"
	^self error: 'documentation only'