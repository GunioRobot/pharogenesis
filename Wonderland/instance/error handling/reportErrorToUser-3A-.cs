reportErrorToUser: errorString
	"When any object in a Wonderland discovers an error it creates an error report and then calls this method to display the error to the user."

	| errWin tm |

	errWin _ SystemWindowWithButton labelled: 'Ooops'.
	errWin openInWorldExtent: 400@100.
	errWin color: (Color white).

	tm _ TextMorph new.
	tm initialize.
	errWin addMorph: tm.

	tm color: (Color red).
	tm contents: errorString wrappedTo: 380.
	tm position: ((errWin position) + (10@20)).
	tm lock.

	errWin height: (tm height) + 30.

	errorSound play.



