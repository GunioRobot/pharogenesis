waitForDataQueryingUserEvery: seconds
	"Wait for data to arrive, asking the user periodically if they wish to keep waiting. If they don't wish to keep waiting, destroy the socket and raise an error."

	| gotData |
	gotData _ false.
	[gotData]
		whileFalse: [
			gotData _ self waitForDataUntil: (Socket deadlineSecs: seconds).
			gotData ifFalse: [
				self isConnected ifFalse: [
					self destroy.
					self error: 'server closed connection'].
				(self confirm: 'server not responding; keep trying?')
					ifFalse: [
						self destroy.
						self error: 'no response from server']]].
