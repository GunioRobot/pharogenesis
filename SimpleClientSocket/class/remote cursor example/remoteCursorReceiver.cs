remoteCursorReceiver
	"Wait for a connection, then display data sent by the client until the client closes the stream. This server process is usually started first (optionally in a forked process), then the sender process is started (optionally on another machine). Note this machine's address, which is printed in the transcript, since the sender process will ask for it."
	"[SimpleClientSocket remoteCursorReceiver] fork"

	| sock response |
	Transcript show: 'starting remote cursor receiver'; cr.
	Transcript show: 'initializing network'; cr.
	Socket initializeNetwork.
	Transcript show: 'my address is ', NetNameResolver localAddressString; cr.
	Transcript show: 'opening connection'; cr.
	sock _ SimpleClientSocket new.
	sock listenOn: 54323.
	sock waitForConnectionUntil: (Socket deadlineSecs: 60).
	sock isConnected
		ifFalse: [
			 sock destroy.
			Transcript show: 'remote cursor receiver did not receive a connection in 60 seconds; aborting.'.
			^ self].
	Transcript show: 'connection established'; cr.

	[sock isConnected]
		whileTrue: [
			sock dataAvailable
				ifTrue: [
					response _ sock getResponse.
					response displayOn: Display at: 10@10]
				ifFalse: [
					"if no data available, let other processes run for a while"
					(Delay forMilliseconds: 20) wait]].

	sock destroy.
	Transcript show: 'remote cursor receiver done'; cr.
