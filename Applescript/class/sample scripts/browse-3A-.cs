browse: anUrl
	"Open Microsoft's Web Browser to a page"
	
	^self doIt: 'tell application "Internet Explorer"
		activate
		openURL "', anUrl, '"
	end tell'