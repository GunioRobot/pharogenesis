frameNumber: n msSinceStart: ms
	"Set the current frame number, and save the scorePlayer's simulated time for synchronization."

	frameAtLastSync _ n.
	msAtLastSync _ ms.
