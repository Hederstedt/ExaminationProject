class Project extends React.Component {
    constructor(props) {
        super(props);
        this.HandleTextAreachangeEvent = this.HandleTextAreachangeEvent.bind(this);
        this.changeImageUrl = this.changeImageUrl.bind(this);
        this.HandleAddObject = this.HandleAddObject.bind(this);
        this.changeImageUrl = this.changeImageUrl.bind(this);
        this.liClickevent = this.liClickevent.bind(this);
        this.Handleheader = this.Handleheader.bind(this);
        this.HandleheadertextEvent = this.HandleheadertextEvent.bind(this);
        this.hide = this.hide.bind(this);
        this.HandleSubmit = this.HandleSubmit.bind(this);
        this.HandleTitleEvente = this.HandleTitleEvente.bind(this);
        this.HandleTitleChange = this.HandleTitleChange.bind(this);
        this.state = {
            workList: [],
            textarea: "",
            imageUrl: "/profilePic",
            file: '',
            selectedIndex: null,
            Header: "Rubrik",
            headerText: "",
            sendHeader: "",
            listempty: true,
            count: 0,
            title: "ge ditt projekt ett namn",
            titletext: "",
            arraySend: []
        };

    }
    HandleAddObject(e) {
        var status = this.state.listempty;
        var counte = this.state.count;
        var obj = { count: this.state.count, title: this.state.title, file: this.state.file, text: this.state.textarea, header: this.state.sendHeader };
        if (status != true) {
            submit(obj);
            counte++;
            var data = new FormData();
            var title = obj.title;
            var file = obj.file;
            var header = obj.header;
            var text = obj.text;
            var count = obj.count;
            console.log(count);
            data.append('count', count)
            data.append('header', header);
            data.append('title', title);
            data.append('text', text);
            data.append('file', file);
            console.log(data);
            var arayli = this.state.arraySend;
            arayli.push(data);
            console.log(arayli);
            this.setState({
                arraySend: arayli,
                count: counte
            })
        }
        let lista = this.state.workList;
        lista.push({ Header: "Rubrik", Image: "/profilePic", Text: "skriv text här" });
        this.setState({
            workList: lista,
            imageUrl: "/profilePic",
            listempty: false
        })

    }
    HandleTextAreachangeEvent(e) {
        this.setState({
            textarea: e.target.value
        });
    }
    changeImageUrl(e) {
        e.preventDefault();
        let lista = this.state.workList;
        let reader = new FileReader();
        let file = e.target.files[0];
        reader.readAsDataURL(file);
        reader.onloadend = () => {
            let ri = reader.result;
            lista[this.state.selectedIndex].Image = ri;
            this.setState({
                file: file,
                imageUrl: reader.result,
                workList: lista,
                selectedIndex: null
            });
        }
    }
    liClickevent(index) {
        this.setState({
            selectedIndex: index
        })
    }
    Handleheader(e) {
        let lista = this.state.workList;
        let newHeader = this.state.headerText;
        lista[this.state.selectedIndex].Header = newHeader;
        this.setState({
            workList: lista,
            sendHeader: newHeader,
            headerText: "",
            selectedIndex: null
        })
    }
    HandleheadertextEvent(e) {
        this.setState({
            headerText: e.target.value
        });
    }
    hide(e) {
        this.setState({
            selectedIndex: null
        })
    }
    HandleTitleEvente(e) {
        this.setState({
            titletext: e.target.value
        })
    }
    HandleTitleChange(e) {
        let newtitle = this.state.titletext;
        this.setState({
            title: newtitle
        })
    }
    HandleSubmit(e) {
        console.log("HandleSubmit");
        var title = this.state.title;
        var data = new FormData();
        data.append('title', title);
        console.log(data);
        var xhr = new XMLHttpRequest();
        xhr.open('post', "/project/test", true);
        xhr.send(data);
       
    }
    /***************************************Det som skall renderas ut skriver du här************/
    render() {
        return (

            <div className="" style={{ backgroundColor: "#377dc8" }}>
                <TitleBox titleHeader={this.state.title} inputTitle={this.state.titletext} inputTitleEvent={this.HandleTitleEvente} changeTitle={this.HandleTitleChange} />
                <ListBox data={this.state.workList}
                    previewImage={this.changeImageUrl}
                    isImage={this.state.isImage}
                    liClickevent={this.liClickevent}
                    header={this.state.Header}
                    selectedIndex={this.state.selectedIndex}
                    changeHeader={this.Handleheader}
                    headerText={this.state.headerText}
                    visable={this.state.visableInput}
                    hide={this.hide}
                    headertextEvent={this.HandleheadertextEvent}
                    areaTextchangeEvent={this.HandleTextAreachangeEvent}
                    textarea={this.state.textarea}
                />
                <br />
                <br />
                <br />
                <ButtonBox addObject={this.HandleAddObject} submit={this.HandleSubmit} />
            </div>);
    }
}
/****************************************Slut på project classen **************************/

function submit(obj) {
    var data = new FormData();
    var title = obj.title;
    var file = obj.file;
    var header = obj.header;
    var text = obj.text;
    var count = obj.count;
    console.log(count);
    data.append('count', count)
    data.append('title', title)
    data.append('header', header);
    data.append('text', text);
    data.append('file', file);
    console.log(data);
    var xhr = new XMLHttpRequest();
    xhr.open('post', "/project/data", true);
    xhr.send(data);
}
class TitleBox extends React.Component {
    render() {
        return (
            <div>
                <h1>{this.props.titleHeader}</h1>
                <input type="text" value={this.props.inputTitle} onChange={this.props.inputTitleEvent} />

                <button className="btn btn-info btn-lg col-md-4" onClick={this.props.changeTitle}>Ändra titel</button>
            </div>
        );
    }
}
class ButtonBox extends React.Component {
    render() {
        return (
            <div className="col-md-12">
                <button className="btn btn-primary btn-lg col-md-4" onClick={this.props.addObject}><i className="fa fa-plus-square" aria-hidden="true"></i>&nbsp;Lägg till ett steg</button>

                <button className="btn btn-success btn-lg col-md-4" onClick={this.props.submit}><i className="fa fa-cloud" aria-hidden="true"></i>&nbsp;Spara</button>

            </div>
        );
    }
}
class ListBox extends React.Component {
    handleClick(index, x, event) {
        this.props.liClickevent(index);
    }
    render() {
        let oldLista = this.props.data;
        let newLista;
        newLista = oldLista.map((x, index) => <div key={index} onMouseOver={this.handleClick.bind(this, index, { x })} onMouseLeave={this.props.hide}>
            <div className="row">
                <div className="col-md-6">
                    <li ><h3>{x.Header}</h3></li>
                </div>
                <div className="col-md-6">
                    <input className={this.props.selectedIndex === index ? '' : 'hidden'} type="text" value={this.props.headerText} onChange={this.props.headertextEvent} />
                    <button className="btn btn-info btn-lg" onClick={this.props.changeHeader}>Ändra Rubrik</button>
                    <br />
                    <label className="btn btn-info btn-lg inputremove">
                        Ändra bild
                    <input type="file" accept=".png, .jpg, .gif, .jpeg, .tif" alt="Ändra bild?"
                            onChange={this.props.previewImage} /></label>
                </div>
            </div>

            <img src={x.Image} />

            <br />
            <textarea className="col-md-10 " onChange={this.props.areaTextchangeEvent} value={this.props.textarea}>{x.Text}</textarea>
            <br />
            <br />
        </div>
        );
        return (<ol>{newLista}</ol>);


    }
}


/***********************slut på React dax att rendera ut **********************************/
ReactDOM.render(<Project submitUrl="/project/data" />, document.getElementById('projectContent'));


/***************************temp**************************************/

 //const url = this.props.submitUrl;
        //let data = this.state.workList;
        //let form = new FormData();
        //data.forEach(element => {
        //    form.append('Image', element.file);
        //    form.append('Header', element.Header);
        //    form.append('Text', element.Text);
        //})
        //console.log(data,form)
        //$.post(url, { things: things },
        //function () {
        //    $('#result').html('"PassThings()" successfully called.');
        //});
        //console.log(data);
        //let fetchData = {
        //    method: 'POST',
        //    body: form,
        //    headers: new Headers()
        //}
        //fetch(url, fetchData)
        //    .then(function () {

        //    });
        //let xhr = new XMLHttpRequest();
        //xhr.open('post', this.props.submitUrl, true);
        //xhr.send(data);