messageListMenu: aMenu

	^ aMenu 
		labels:
'fileIn
fileOut
senders (n)
implementors (m)
method inheritance (h)
versions (v)
remove'
		lines: #(2 6)
		selections: #(fileInMessage fileOutMessage
browseSenders browseImplementors methodHierarchy browseVersions
removeMessage).