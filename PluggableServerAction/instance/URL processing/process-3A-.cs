process: request
	processBlock value: request.
	request reply: PWS success; reply: PWS contentHTML, PWS crlf.
	request reply: (returnBlock value: request).
