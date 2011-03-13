pruneStaleConnections
	"Private! The client may establish a connection and then disconnect while it is still in the connection queue. This method is called periodically to prune such sockets out of the connection queue and make room for fresh connections."

	| foundStaleConnection |
	accessSema critical: [
		foundStaleConnection _ false.
		connections do: [:s |
			s isUnconnected ifTrue: [
				s destroy.
				foundStaleConnection _ true]].
		foundStaleConnection ifTrue: [
			connections _ connections select: [:s | s isValid]]].
