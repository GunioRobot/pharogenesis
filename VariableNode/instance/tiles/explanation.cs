explanation

	self isSelfPseudoVariable ifTrue: [^'the pseudo variable <self> (refers to the receiver)'].
	^(#('instance' 'temporary' 'LIT3' 'global') 
			at: self type 
			ifAbsent: ['UNK',self type printString]),' variable <',self name,'>'
		

	"LdInstType _ 1.
	LdTempType _ 2.
	LdLitType _ 3.
	LdLitIndType _ 4.
"

