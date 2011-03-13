defaultsQuadsDefiningWidgetsFlap
	"Answer a structure defining the default Widgets flap.
     previously in quadsDefiningWidgetsFlap"

	^ #(
	(RecordingControlsMorph	authoringPrototype		'Sound'				'A device for making sound recordings.')
	(MPEGMoviePlayerMorph	authoringPrototype		'Movie Player'		'A Player for MPEG movies')
	(FrameRateMorph		authoringPrototype			'Frame Rate'		'An indicator of how fast your system is running')
	(MagnifierMorph		newRound					'Magnifier'			'A magnifying glass')
	(BouncingAtomsMorph	new						'Bouncing Atoms'	'Atoms, mate')
	) asOrderedCollection