fullControlSpecs
	^ #(	
			('<<>>'		invokeBookMenu 'Invoke menu')
			( '<--'		firstPage		'Go to first page')
			( '<<'		playReverse		'Play backward')
			( '<-' 		previousPage	'Back one frame')
			( '| |' 		stopPlay		'Stop playback')
			('->'			nextPage		'Forward one frame')
			('>>'			playForward	'Play forward')
			( '-->'		lastPage			'Go to final page'))