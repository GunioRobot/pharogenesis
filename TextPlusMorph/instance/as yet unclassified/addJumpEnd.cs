addJumpEnd

	| ed attribute jumpLabel selectedString |

	ed _ self editor.
	selectedString _ ed selection asString.
	selectedString isEmpty ifTrue: [^self inform: 'Please select something first'].
	jumpLabel _ FillInTheBlank request: 'Name this place' initialAnswer: selectedString.
	jumpLabel isEmpty ifTrue: [^self].
	self removeJumpEndFor: jumpLabel.
	attribute _ TextPlusJumpEnd new jumpLabel: jumpLabel.
	ed replaceSelectionWith: (ed selection addAttribute: attribute).

