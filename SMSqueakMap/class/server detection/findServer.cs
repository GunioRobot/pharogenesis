findServer
	"Go through the list of known master servers, ping 
	each one using simple http get on a known 'ping'-url 
	until one responds return the server name. 
	If some servers are bypassed we write that to Transcript. 
	If all servers are down we inform the user and return nil."

	| notAnswering deafServers |
	Socket initializeNetwork.
	notAnswering := OrderedCollection new.
	Cursor wait
		showWhile: [ServerList
				do: [:server | (self pingServer: server)
						ifTrue: [notAnswering isEmpty
								ifFalse: [deafServers := String
												streamContents: [:str | notAnswering
														do: [:srvr | str nextPutAll: srvr printString;
																 nextPut: Character cr]].
									Transcript show: ('These SqueakMap master servers did not respond:\' , deafServers , 'Falling back on ' , server printString , '.') withCRs].
							^ server]
						ifFalse: [notAnswering add: server]]].
	deafServers := String
				streamContents: [:str | notAnswering
						do: [:srvr | str nextPutAll: srvr printString;
								 nextPut: Character cr]].
	self error: ('All SqueakMap master servers are down:\' , deafServers , '\ \Can not update SqueakMap...') withCRs.
	^ nil