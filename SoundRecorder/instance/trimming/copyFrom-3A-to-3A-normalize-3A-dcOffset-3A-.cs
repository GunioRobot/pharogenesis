copyFrom: startPlace to: endPlace normalize: nFactor dcOffset: dcOffset
	"Return a new SoundBuffer containing the samples in the given range."

	| startBufIndex startSampleIndex endBufIndex endSampleIndex
	 count resultBuf j buf firstInBuf n |
	startBufIndex _ startPlace at: 1.
	startSampleIndex _ startPlace at: 2.
	endBufIndex _ endPlace at: 1.
	endSampleIndex _ endPlace at: 2.

	startBufIndex = endBufIndex
		ifTrue: [count _ endSampleIndex + 1 - startSampleIndex]
		ifFalse: [
			count _ ((recordedBuffers at: startBufIndex) size + 1 - startSampleIndex).  "first buffer"
			count _ count + endSampleIndex.  "last buffer"
			startBufIndex + 1 to: endBufIndex - 1 do:
				[:i | count _ count + (recordedBuffers at: i) size]].  "middle buffers"
	resultBuf _ SoundBuffer newMonoSampleCount: count.

	j _ 1.  "next destination index in resultBuf"
	startBufIndex to: endBufIndex do: [:i |
		buf _ recordedBuffers at: i.
		firstInBuf _ 1.
	 	n _ buf size.
		i = startBufIndex ifTrue: [
			n _ (recordedBuffers at: startBufIndex) size + 1 - startSampleIndex.
			firstInBuf _ startSampleIndex].
		i = endBufIndex ifTrue: [
			i = startBufIndex
				ifTrue: [n _ endSampleIndex + 1 - startSampleIndex]
				ifFalse: [n _ endSampleIndex]].
		self copyTo: resultBuf from: j to: (j + n - 1)
			from: buf startingAt: firstInBuf
			normalize: nFactor dcOffset: dcOffset.
		j _ j + n].
	^ resultBuf
