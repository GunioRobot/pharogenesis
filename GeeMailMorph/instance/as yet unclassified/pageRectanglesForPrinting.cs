pageRectanglesForPrinting

	| pageBreaks prevBottom pageRects r |

	pageBreaks _ self valueOfProperty: #pageBreakRectangles ifAbsent: [^nil].
	prevBottom _ 0.
	pageRects _ pageBreaks collect: [ :each |
		r _ 0@prevBottom corner: self width @ each top.
		prevBottom _ each bottom.
		r
	].
	pageRects add: (0@prevBottom corner: self width @ thePasteUp bottom).
	^pageRects