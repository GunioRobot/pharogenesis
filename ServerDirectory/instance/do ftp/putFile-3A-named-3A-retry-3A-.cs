putFile: fileStream named: fileNameOnServer retry: aBool
	"ar 11/24/1998 Do the usual putFile:named: operation but retry if some error occurs and aBool is set. Added due to having severe transmission problems on shell.webpage.com."
	| resp |
	type == #file ifTrue: [
		^ (FileDirectory on: urlObject pathForDirectory)
			putFile: fileStream named: fileNameOnServer].

	[[resp _ self putFile: fileStream named: fileNameOnServer] 
		ifError:[:err :rcvr| resp _ '5xx ',err]. "Report as error"
	aBool and:[((resp isKindOf: String) and: [resp size > 0]) and:[resp first ~= $2]]] whileTrue:[
		(self confirm:('Error storing ',fileNameOnServer,' on the server.\(',resp,',)\Retry operation?') withCRs) ifFalse:[^resp].
	].
	^resp