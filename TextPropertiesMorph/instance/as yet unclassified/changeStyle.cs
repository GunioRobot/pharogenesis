changeStyle

	| aList reply style |

	aList _ StrikeFont actualFamilyNames.
	aList addFirst: 'DefaultTextStyle'.
	reply _ (SelectionMenu labelList: aList lines: #(1) selections: aList) startUp.
	reply ifNil: [^self].

	(style _ TextStyle named: reply) ifNil: [Beeper beep. ^ true].
	self applyToWholeText ifTrue: [self activeEditor selectAll].
	self activeEditor changeStyleTo: style copy.
	self activeTextMorph updateFromParagraph.