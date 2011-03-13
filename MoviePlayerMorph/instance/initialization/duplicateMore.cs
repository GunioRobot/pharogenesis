duplicateMore
	"Duplicate dies not replicate Forms, but MoviePlayers need this."

	frameBufferIfScaled _ frameBufferIfScaled deepCopy.
	currentPage image: currentPage image deepCopy.
