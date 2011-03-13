bmpPixelDataFrom: aBinaryStream width: w height: h depth: d
	"Read uncompressed pixel data of depth d from the given BMP stream, where d is 1, 4, or 8."

	| form bytesPerRow pixelData pixelLine startIndex |
	form _ ColorForm extent: w@h depth: d.  "color map filled in by caller"
	bytesPerRow _ (((d* w) + 31) // 32) * 4.
	pixelData _ ByteArray new: bytesPerRow * h.
	h to: 1 by: -1 do: [:y |
		pixelLine _ aBinaryStream next: bytesPerRow.
		startIndex _ ((y - 1) * bytesPerRow) + 1.
		pixelData
			replaceFrom: startIndex
			to: startIndex + bytesPerRow - 1
			with: pixelLine
			startingAt: 1].
	form bits copyFromByteArray: pixelData.
	^ form
