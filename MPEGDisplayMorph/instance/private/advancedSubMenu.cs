advancedSubMenu
	"private - create the advanced submenu"

	| subMenu |

	subMenu := MenuMorph new.
	subMenu defaultTarget: self.

	repeat
		ifTrue: [subMenu add: 'turn off repeat (now on)' translated action: #toggleRepeat]
		ifFalse: [subMenu add: 'turn on repeat (now off)' translated action: #toggleRepeat].

	subMenu addLine.

	subMenu addList:	{
		{'set frame rate' translated.									#setFrameRate}.
		#-.
		{'create JPEG movie from MPEG' translated.				#createJPEGfromMPEG}.
		{'create JPEG movie from SqueakMovie' translated.		#createJPEGfromSqueakMovie}.
		{'create JPEG movie from folder of frames' translated.	#createJPEGfromFolderOfFrames}
	}.

	(mpegFile isKindOf: JPEGMovieFile) ifTrue: [
		subMenu addLine.
		mpegFile hasAudio
			ifTrue: [subMenu add: 'remove all soundtracks' translated action: #removeAllSoundtracks]
			ifFalse: [subMenu add: 'add soundtrack' translated action: #addSoundtrack]].

	^ subMenu
