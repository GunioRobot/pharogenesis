mouseUp: evt

	soundsPlayingMorph ifNotNil: [soundsPlayingMorph delete].
	soundsPlaying ifNotNil: [soundsPlaying do: [:s | s stopGracefully]].
	soundsPlayingMorph _ soundsPlaying _ nil
