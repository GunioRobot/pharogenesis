informUntilClick: aString  
	"Present aString to the user, and keep it on screen until user clicks the mouse.  1/22/96 sw"
 
	"Utilities informUntilClick: 'Note how this works'"
	self informUser: aString while: [Sensor anyButtonPressed not]