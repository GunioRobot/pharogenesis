otherButtonFor: aButton
	"Find the corresponding button for either a pickup or a stamp button"

	| ii |
	(ii _ pickupButtons indexOf: aButton) > 0 ifTrue: [^ stampButtons at: ii].
	(ii _ stampButtons indexOf: aButton) > 0 ifTrue: [^ pickupButtons at: ii].
	self error: 'stamp button not found'.