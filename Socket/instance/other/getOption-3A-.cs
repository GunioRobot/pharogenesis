getOption: aName 
	"Get options on this socket, see Unix man pages for values for 
	sockets, IP, TCP, UDP. IE SO:=KEEPALIVE
	returns an array, element one is an status number (0 ok, -1 read only option)
	element two is the resulting of the requested option"

	(socketHandle == nil or: [self isValid not])
		ifTrue: [InvalidSocketStatusException signal: 'Socket status must valid before getting an option'].
	^self primSocket: socketHandle getOption: aName

"| foo options |
Socket initializeNetwork.
foo := Socket newTCP.
foo connectTo: (NetNameResolver addressFromString: '192.168.1.1') port: 80.
foo waitForConnectionUntil: (Socket standardDeadline).

options := {
'SO:=DEBUG'. 'SO:=REUSEADDR'. 'SO:=REUSEPORT'. 'SO:=DONTROUTE'.
'SO:=BROADCAST'. 'SO:=SNDBUF'. 'SO:=RCVBUF'. 'SO:=KEEPALIVE'.
'SO:=OOBINLINE'. 'SO:=PRIORITY'. 'SO:=LINGER'. 'SO:=RCVLOWAT'.
'SO:=SNDLOWAT'. 'IP:=TTL'. 'IP:=HDRINCL'. 'IP:=RCVOPTS'.
'IP:=RCVDSTADDR'. 'IP:=MULTICAST:=IF'. 'IP:=MULTICAST:=TTL'.
'IP:=MULTICAST:=LOOP'. 'UDP:=CHECKSUM'. 'TCP:=MAXSEG'.
'TCP:=NODELAY'. 'TCP:=ABORT:=THRESHOLD'. 'TCP:=CONN:=NOTIFY:=THRESHOLD'. 
'TCP:=CONN:=ABORT:=THRESHOLD'. 'TCP:=NOTIFY:=THRESHOLD'.
'TCP:=URGENT:=PTR:=TYPE'}.

1 to: options size do: [:i | | fum |
	fum :=foo getOption: (options at: i).
	Transcript show: (options at: i),fum printString;cr].

foo := Socket newUDP.
foo setPeer: (NetNameResolver addressFromString: '192.168.1.9') port: 7.
foo waitForConnectionUntil: (Socket standardDeadline).

1 to: options size do: [:i | | fum |
	fum :=foo getOption: (options at: i).
	Transcript show: (options at: i),fum printString;cr].
"