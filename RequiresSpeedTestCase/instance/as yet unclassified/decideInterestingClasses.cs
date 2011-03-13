decideInterestingClasses
	interestingCategories := {
				'Morphic-Basic'.
				'Morphic-Books'.
				'Morphic-Demo'.
				'System-Compression'.
				'System-Compiler'
			}.
	displayedClasses := self classesInCategories: interestingCategories.
	focusedClasses := {
				AlignmentMorph.
				GZipReadStream.
				CommentNode
			}