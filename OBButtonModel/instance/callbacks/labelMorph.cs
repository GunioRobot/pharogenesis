labelMorph
	^ (StringMorph 
		contents: self label 
		font: TextStyle defaultFont)
			color: (self isEnabled ifTrue: [Color black] ifFalse: [Color gray]);
			yourself