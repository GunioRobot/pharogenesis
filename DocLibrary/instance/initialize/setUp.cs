setUp
	"set up the External version"
	| email |
	self initialize.
	External _ self.
	group _ 'Squeak Public Updates'.	"right for http, but not for ftp"
	lastUpdate _ 599.
	lastUpdateName _ 'MTMcontainsPoint-ar.cs'.
	DropBox _ ServerDirectory new.
	DropBox server: 'squeak.cs.uiuc.edu'; directory: 'incoming'.
	DropBox type: #ftp.
	email _ nil.  "Celeste popUserName."	"If nil, we ask at drop time"
	DropBox user: 'anonymous'; password: email.
	DropBox moniker: 'Doc Pane DropBox'.
		"later allow a second server"
