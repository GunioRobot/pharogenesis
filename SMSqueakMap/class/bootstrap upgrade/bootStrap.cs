bootStrap
	"Bootstrap upgrade. Only used when SqueakMap itself is too old to
	communicate with the server. This relies on the existence of a package
	called SqueakMap that is a .st loadscript. The loadscript needs to do its
	own changeset management."

	| server url |
	server := self findServer.
	server ifNotNil: ["Ok, found a SqueakMap server"
		url := (('http://', server, '/packagebyname/squeakmap/downloadurl')
				asUrl retrieveContents content) asUrl.
		(url retrieveContents content unzipped readStream)
				fileInAnnouncing: 'Upgrading SqueakMap...']