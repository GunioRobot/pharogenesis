name: pageName date: dateString time: timeString by: who text: theString
back: bytes
	"Record the name of this page during startup.  When reading the
page in order to serve it, this is NOT executed.  The text is read from the
file explicitly."

	name _ pageName.
	date _ dateString asDate.
	time _ timeString asTime.
	address _ who