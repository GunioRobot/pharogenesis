autoMove
	"automatically pick a folder for the current message, and move the message there"
	| folder |
	mailDB ifNil: [ ^self ].
	folder := self chooseFilterForCurrentMessage.
	folder ifNil: [ ^self].
	self lastCategory: folder.
	mailDB file: currentMsgID inCategory: folder.
	self removeMessage.