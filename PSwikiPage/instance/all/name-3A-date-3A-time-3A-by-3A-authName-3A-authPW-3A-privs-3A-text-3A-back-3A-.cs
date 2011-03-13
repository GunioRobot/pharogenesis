name: pageName date: dateString time: timeString by: who authName: aName authPW: thePass privs: thePrivs text: theString back: bytes
	"Record the name of this page during startup.  When reading the page in order to serve it, this is NOT executed.  The text is read from the file explicitly."
	
	name _ pageName.
	date _ dateString asDate.
	username _ aName.
	password _ thePass.
	privs _ thePrivs.