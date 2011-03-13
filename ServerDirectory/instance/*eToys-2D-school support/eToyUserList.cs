eToyUserList
	"Return a list of all known users for eToy login support"
	| urlString |
	eToyUserList ifNotNil:[^eToyUserList].
	urlString _ self eToyUserListUrl.
	urlString ifNil:[^nil].
	eToyUserList _ self class parseEToyUserListFrom: urlString.
	^eToyUserList