howToStart
	"To set up your new Swiki, you need a copy of the 'Server' folder found at: 
http://www.cc.gatech.edu/fac/mark.guzdial/squeak/pws/
Put the 'Server' folder into the folder that your image is in.

Modify this method to be a path to your Server folder, select it, and choose fileItIn:
!ServerAction class methodsFor: 'System Services' stamp: 'tk 1/19/98 12:52'!
serverDirectory
	^ 'Hard Disk:Squeak1.31:Server:'
! !

Then do:
	PWS initializeAll.

To enable a new Swiki called OurOwnArea.
Make a folder named OurOwnArea in the Server folder.  Then do:
	SwikiAction setUp: 'OurOwnArea'.
	(its main URL is http://thisMachine:80/OurOwnArea.1)

Suppose you already have a Swiki called 'myswiki'.
To start up:
	SwikiAction new restore: 'myswiki'.		'<- New line for each additional Swiki area'.
	SwikiAction new restore: 'myswiki'.		'Case DOES matter in the name of Swiki here.'.
	PWS serveOnPort: 80 loggingTo: 'log.txt'.

To stop the server: 
	PWS stopServer.

-----------------------
To purge a particular file of all except the latest version:
	((PWS actions at: 'myswiki' asLowercase) urlmap atID: '3') condenseChanges.

To roll the entire wiki back to a previous time:
	""This does not erase data, it just copies the older page to the end""
	(PWS actions at: 'myswiki' asLowercase) rollBack: '1/28/98' asDate 
			at: '1:30 am' asTime.

The look of a served page is controlled by a template.  Templates live in the 'swiki' folder in the 'Server' folder.  Beware that templates are cached by HTMLformatter.  If you change a template, you will not see the effect until you reload the Swiki.

To set up a Swiki with a password (same for all users), see AuthorizedSwikiAction comment.

To enable a privledged user to execute code remotely (on a workspace page):
	(PWS actions at: 'authorized') mapName: 'JSmith' password: 'hard2guess' to: 'JSmith'.
	(URL is http://thisMachine:80/authorized.workspace.html)

To backup the user data to the disk, do nothing.  All info is already inside the page files on the disk.

To enable a new Swiki that evaluates Squeak code submitted by the user.
Make a folder named SqkEval in the Server folder.  Then do:
	ActiveSwikiAction setUp: 'SqkEval'.
	(this is dangerous, because there are still ways a user could crash your server)

To convert from an old pre-Squeak1.3 Swiki to the new page format: 
	(In the old image, do a backup:)
		| mine | mine _ PWS actions at: 'myswiki'.
		mine saveTo: mine path,'backup28JanA'.
	(Quit.  Start the new image which has this version of the Swiki code)
	(Do not start the server!!!)
		PWS initializeAll.
		SwikiAction restore: 'myswiki' from: 
			(ServerAction serverDirectory), 'myswiki:backup28JanA'.
		(PWS actions at: 'myswiki' asLowercase) convert.
	(do these steps for each Swiki you have)
	(now, start the server)
	PWS serveOnPort: 80 loggingTo: 'log.txt'.
"