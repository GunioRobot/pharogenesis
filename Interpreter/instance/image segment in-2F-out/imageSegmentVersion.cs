imageSegmentVersion
	| wholeWord |
	"a more complex version that tells both the word reversal and the endianness of the machine it came from.  Low half of word is 6502.  Top byte is top byte of #doesNotUnderstand: on this machine. ($d on the Mac or $s on the PC)"

	wholeWord _ self longAt: (self splObj: SelectorDoesNotUnderstand) + BaseHeaderSize.
		"first data word, 'does' "
	^ self imageFormatVersion bitOr: (wholeWord bitAnd: 16rFF000000)