howToStart
	"To set up your new Swiki, you need a copy of the 'Server' folder found at: 
http://www.cc.gatech.edu/fac/mark.guzdial/squeak/pws/
Put the 'Server' folder into the folder that your image is in.

Modify this method to be a path to your Server folder, select it, and fileItIn:
!ServerAction class methodsFor: 'System Services' stamp: 'tk 1/19/98 12:52'!
serverDirectory
	^ 'Home Plate:ETSqueak1.31b:Server:'
! !

Then do:
	PWS initializeAll.

To enable a new Swiki called OurOwnArea.
Make a folder named OurOwnArea in the Server folder.  Then do:
	SwikiAction setUp: 'OurOwnArea'.
	(its main URL is http://thisMachine:80/OurOwnArea.1)

Suppose you already have a Swiki called 'myswiki'.
To start up:
	SwikiAction new restore: 'myswiki'.
	[PWS serveOnPort: 80 loggingTo: 'log.txt'] fork.
		(when you have more Swikis, such as OurOwnArea, you must add a line to restore each one.  Whenever you start up Squeak, you must restore each swiki, before forking the process that serves pages.)

To stop the server: 
	PWS stopServer.


To convert from an old pre-Squeak1.3 Swiki to new page format: 
	(In the old image, do a backup:)
		| mine | mine _ PWS actions at: 'myswiki'.
		mine saveTo: mine path,'backup28JanA'.
	(Quit.  Start the new image which has this version of the Swiki code)
	(Do not start the server!!!)
		PWS initializeAll.
		SwikiAction restore: 'myswiki' from: 
			(ServerAction serverDirectory), 'myswiki:backup28JanA'.
		(PWS actions at: 'myswiki') convert.
	(do these steps for each Swiki you have)
	(now, start the server)
	[PWS serveOnPort: 80 loggingTo: 'log.txt'] fork.

To backup (new format)
	(do nothing.  All info is already inside the page files on the disk.)

To enable a new Swiki that evaluates Squeak code submitted by the user.
Make a folder named SqkEval in the Server folder.  Then do:
	ActiveSwikiAction setUp: 'SqkEval'.
	(this is dangerous, because there are still ways a user could crash your server)

To purge a file of all except the latest version:
	((PWS actions at: 'myswiki') urlmap atID: 3) condenseChanges.

To roll the entire wiki back to a previous time:
	""This does not erase data, it just moves an older page to the end""
	(PWS actions at: 'myswiki') rollBack: '1/28/98' asDate 
			at: '1:30 am' asTime.

"