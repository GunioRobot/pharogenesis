autoFile
	"automatically pick a folder for the current message, and file the current message there"
	| folder |
	mailDB ifNil: [ ^self ].
	folder := self chooseFilterForCurrentMessage.
	folder ifNil: [ ^self].
	self lastCategory: folder.
	mailDB file: currentMsgID inCategory: folder.