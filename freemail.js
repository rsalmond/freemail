var freemail = (function () {
	var disposable = [];
	var free = [];

	function readFile(path, setResult) {
		var url = document.location.origin + path;
		$.ajax({
			url: url,
			dataType: 'text',
			success: function (text) {
				setResult(text);
			},
			error: function () {
				throw "error reading file";
			}
		});
	}

	readFile("/Scripts/freemail/disposable.txt", function (content) {
		var domains = content.split('\r\n');
		disposable.push.apply(disposable, domains);
		free.push.apply(free, domains);
	});
	readFile("/Scripts/freemail/free.txt", function (content) {
		var domains = content.split('\r\n');
		free.push.apply(free, domains);
	});

	return {
		isFree: function (email) {
			if (typeof email !== 'string') throw new TypeError('email must be a string');
			var domain = email.split('@').pop();
			return free.indexOf(domain) !== -1;
		},
		isDisposable: function (email) {
			if (typeof email !== 'string') throw new TypeError('email must be a string');
			var domain = email.split('@').pop();
			return disposable.indexOf(domain) !== -1;
		}
	};
}());

