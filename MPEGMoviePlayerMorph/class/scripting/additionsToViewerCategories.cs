additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(
	(basic
		(
			(command play 'Start playing the movie/sound')
			(command stop 'Stop playing the movie/sound')
			(command rewind 'Rewind the movie/sound')))

	(#'movie controls'
		(
			(slot videoFileName	'The name for the video file' 											String	readWrite Player getVideoFileName Player setVideoFileName:)
			(slot subtitlesFileName	'The name for the subtitles file' 										String	readWrite Player getSubtitlesFileName Player setSubtitlesFileName:)
			(slot position 			'A number representing the current position of the movie/sound.'	Number readWrite Player getPosition Player setPosition:)
			(slot volume 			'A number representing the volume of the movie.' 					Number readWrite Player getVolume Player setVolume:)

			(command play 'Start playing the movie/sound')
			(command playUntilPosition: 'Play until the given position, then stop' Number)			
			(command stop 'Stop playing the movie/sound')
			(command rewind 'Rewind the movie/sound')

			(slot isRunning 'Whether the movie/sound is being played' Boolean readOnly	Player getIsRunning unused unused)
			(slot repeat 'Whether the movie/sound will play in an endless loop' Boolean readWrite	Player getRepeat Player setRepeat:)
			(slot totalFrames 'Length of this movie in number of frames' Number readOnly	Player getTotalFrames unused unused)
			(slot totalSeconds 'Length of this movie in seconds' Number readOnly	Player getTotalSeconds unused unused)
			(slot frameGraphic 'A graphic for the current frame' Graphic readOnly Player getFrameGraphic unused unused)
		)
	)

)