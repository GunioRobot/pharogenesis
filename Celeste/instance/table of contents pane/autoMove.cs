autoMove
	"automatically pick a folder for the current message, and move the message there"
	| folder |
	folder := self chooseFilterForCurrentMessage.
	folder ifNil: [ ^self].
	mailDB file: currentMsgID inCategory: folder.
	self removeMessage.