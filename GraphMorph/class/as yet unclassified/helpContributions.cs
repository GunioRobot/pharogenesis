helpContributions

	^ #((clear
			'Clear the graph of current contents')
		(loadSineWave
			'Load a sine wave as the current graph')
		(loadSound: 
			'Load the specified sound into the current graph')
		(command
			'Reverse the graph')
		(play
			'Play the current graph as a sound')
		(cursorWrapped
			'The current cursor location, wrapped back to the beginning if appropriate')
		(sampleAtCursor
			'The sample value at the current cursor location')
		(lastValue
			'The last value obtained')
		(reverse
			'Reverse the graph'))
