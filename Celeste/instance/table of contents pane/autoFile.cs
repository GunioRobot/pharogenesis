autoFile
	"automatically pick a folder for the current message, and file the current message there"
	| folder |
	folder := self chooseFilterForCurrentMessage.
	folder ifNil: [ ^self].
	mailDB file: currentMsgID inCategory: folder.