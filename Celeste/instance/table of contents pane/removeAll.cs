removeAll
	"Remove all presently listed messages from the current category."
	mailDB ifNil: [ ^self ].
	self category ifNil: [ ^self ].
	mailDB removeAll: currentMessages fromCategory: self category.
	currentMsgID _ nil.

	"Regenerate the (possibly empty) TOC for this category"
	self updateTOC.