disablePageBreaksWhile: aBlock

	| save result |

	save _ showPageBreaks.
	showPageBreaks _ false.
	result _ aBlock value.
	showPageBreaks _ save.
	^result
