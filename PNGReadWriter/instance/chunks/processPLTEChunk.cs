processPLTEChunk
	| colorCount colors i |
	colorCount _ chunk size // 3. "TODO - validate colorCount against
depth"
	colors _ Array new: colorCount.
	0 to: colorCount-1 do: [ :index |
		i _ index * 3 + 1.
		colors at: index+1 put:
			(Color r: (chunk at: i)/255 g: (chunk at: i+1)/255 b: (chunk at: i+2)/255)
		].
	form colors: colors
