initializeSyntaxColorsAndStyles
	| specs |
	"To change the color choices, you can simply edit this method, and then evaluate the following line:

		Preferences initializeSyntaxColorsAndStyles

	Later, people may wish to produce interactive editors for modifying the choices"

	SyntaxColorsAndStyles _ IdentityDictionary new.
	# (	(temporaryVariable		(magenta		bold))
		(methodArgument		(magenta		italic))
		(blockArgument			(magenta		italic))

		(comment				(red				normal))

		(variable				(blue			bold))

		(literal					(brown			normal))

		(keyword				(black	 		normal)))

	do:
		[:nameAndSpecs |
			specs _ nameAndSpecs second.
			SyntaxColorsAndStyles at:  nameAndSpecs first put: (SyntaxAttribute color: (Color perform: specs first) emphasis: specs last)]
		