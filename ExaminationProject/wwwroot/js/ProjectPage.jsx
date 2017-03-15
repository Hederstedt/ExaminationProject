let textLista = [];
class Project extends React.Component {
    constructor(props) {
        super(props);
        this.AddTextBox = this.AddTextBox.bind(this);
        this.changeEvent = this.changeEvent.bind(this);
        this.changeImageUrl = this.changeImageUrl.bind(this);
        this.AddImageBox = this.AddImageBox.bind(this);
        this.changeImageUrl = this.changeImageUrl.bind(this);
        this.liClickevent = this.liClickevent.bind(this);
        this.state = {
            error: "problems",
            texter: textLista,
            textarea: "",
            imageUrl: "/profilePic",
            isImage: true,
            selectedIndex: index
        };
    }
    AddTextBox(e) {
        let newtxt = this.state.texter;
        newtxt.push(this.state.textarea);
        this.setState({
            isImage: false,
            texter: newtxt,
            textarea: ""
        })
    }
    AddImageBox(e) {
        let lista = this.state.texter;
        lista.push("/profilePic");
        this.setState({
            isImage: true,
            texter: lista,
            imageUrl: "/profilePic"
        })
    }
    changeEvent(e) {
        this.setState({
            textarea: e.target.value
        });
    }
    changeImageUrl(e) {
        e.preventDefault();
        let lista = this.state.texter;
        let reader = new FileReader();
        let file = e.target.files[0];
        reader.readAsDataURL(file)
        reader.onloadend = () => {
            let ri = reader.result;
            lista.splice(this.state.selectedIndex, 1, ri)
            this.setState({
                imageUrl: reader.result,
                texter: lista
            });
        }
    }
    liClickevent(index) {
        this.setState({
            selectedIndex: index
        })
    }
        /*<ImageBox ImageUrl={this.state.imageUrl} previewImage={this.changeImageUrl} />*/
        /***************************************Det som skall renderas ut skriver du här************/
        render() {
            return (
                <div className="col-md-12">
                    <ListBox data={this.state.texter}
                        pfile={this.state.imageUrl}
                        previewImage={this.changeImageUrl}
                        isImage={this.state.isImage}
                        liClickevent={this.liClickevent}
                    />
                    <br />
                    <TextBox textarea={this.state.textarea} changeEvent={this.changeEvent} />
                    <br />
                    <br />
                    <ButtonBox addTextBox={this.AddTextBox} addImageBox={this.AddImageBox} />
                </div>);
        }
    }
/****************************************Slut på project classen **************************/
class FilterBox extends React.Component {
    render() {
        return (<label className="labelfilter">Filter&nbsp;&nbsp;<input className="inputfilter" placeholder="Sök här" /></label>);
    }
}
class ButtonBox extends React.Component {
    render() {
        return (
            <div className="col-md-12 ">
                <button className="btn btn-primary btn-lg col-md-4" onClick={this.props.addTextBox}><i className="fa fa-plus-square" aria-hidden="true"></i></button>
                <button className="btn btn-primary btn-lg col-md-4" onClick={this.props.addImageBox}><i className="fa fa-plus-square" aria-hidden="true"></i></button>
            </div>
        );
    }
}
class TextBox extends React.Component {
    render() {
        return (<textarea className="col-md-10 center" onChange={this.props.changeEvent} value={this.props.textarea}></textarea>);
    }
}
class ListBox extends React.Component {
    handleClick(index, x, event) {
        this.props.liClickevent(index);
    }
    render() {
        let oldLista = this.props.data;
        let newLista;
        if (this.props.isImage) {
            newLista = oldLista.map((x, index) => <div key={index}>
                <li onClick={this.handleClick.bind(this, index, { x })}>
                    <img src={x} />
                </li>
                <input className="btn btn-Info btn-lg" value="Ändra bild" type="file" accept=".png, .jpg, .gif, .jpeg, .tif" alt="Ändra bild?"
                    onChange={this.props.previewImage} />
            </div>
            );
            return (<ul>{newLista}</ul>);
        }
        else {
            newLista = oldLista.map((x, index) => <div key={index}>
                <li>
                    {x}
                </li>
            </div>
            );
            return (<ul>{newLista}</ul>);
        }

    }
}
class ImageBox extends React.Component {
    render() {

        return (
            <div className="inputremove">
                <label htmlFor="inputWorkImage"><img id="test" src={this.props.ImageUrl} /></label>
                <input id="inputWorkImage" className="profilePic" type="file" accept=".png, .jpg, .gif, .jpeg, .tif" alt="Ändra bild?"
                    onChange={this.props.previewImage} />
            </div>
        );

    }
}

/***********************slut på React dax att rendera ut **********************************/
ReactDOM.render(<Project />, document.getElementById('projectContent'));


/***************************temp**************************************/
/*
  <li>
                    <label className="inputremove"><img src={x} />
                        <input className="profilePic" type="file" accept=".png, .jpg, .gif, .jpeg, .tif" alt="Ändra bild?"
                            onChange={this.props.previewImage} />
                    </label>
                </li>






                {document.getElementById('test').src = window.URL.createObjectURL(this.files[0])}
                <label asp-for="AvatarImage" class="col-md-2  col-md-offset-2 control-label"><img id="RegPageImage" src="@Url.Action(" ProfilePic", "Home")" class="profilePicRoundMedium" /></label>
    <div class="inputremove">
        <input asp-for="AvatarImage" class="profilePic" type="file" typeof="file" accept=".png, .jpg, .jpeg, .gif, .tif" alt="Lägg till en bild"
            onchange="document.getElementById('RegPageImage').src = window.URL.createObjectURL(this.files[0])" />
    </div>







*/








//let apiData;
//let landList = [];
//let listElement;
//class App extends React.Component {
//    constructor(props) {
//        super(props);
//        this.liClickevent = this.liClickevent.bind(this);
//        this.filterTextChange = this.filterTextChange.bind(this);
//        this.delClick = this.delClick.bind(this);
//        this.inputText = this.inputText.bind(this);
//        this.blur = this.blur.bind(this);
//        this.state =
//            {
//                error: 'noProblemo',
//                count: 3,
//                lista: landList,
//                filterText: '',
//                selectedCountryIndex: null
//            };
//    }

//    filterTextChange(e) {
//        this.setState(
//            {
//                filterText: e.target.value
//            });
//    }

//    delClick(e) {
//        let countries = this.state.lista;
//        countries.splice(this.state.selectedCountryIndex, 1);
//        this.setState({
//            lista: countries,
//            selectedCountryIndex: null
//        })
//    }

//    liClickevent(index) {
//        this.setState({
//            selectedCountryIndex: index
//        })

//    }
//    inputText(e) {
//        const newTxt = e.target.value;
//        let countries = this.state.lista;
//        countries.splice(this.state.selectedCountryIndex, 1, newTxt);
//        this.setState({
//            lista: countries
//        })
//    }
//    blur(e) {
//        this.setState({
//            selectedCountryIndex: null
//        })
//    }

//    render() {
//        if (this.state.count > 0) {
//            if (this.state.count % 2 == 0) {
//                return (<div><span className="spancountdownmo">Din data är klar om: {this.state.count} sekunder</span></div>);
//            }
//            else {
//                return (<div><span className="spancountdown">Din data är klar om: {this.state.count} sekunder</span></div>);
//            }

//        }
//        else {
//            console.log(this.state.error)
//            if (this.state.error != 'noProblemo') {
//                return (<div><span className="errormessage">Det blev visst något fel när vi skulle hämta datan ? du kanske måste tillåta osäkra scripts?</span></div>);
//            }
//            else {
//                return (
//                    <div className="divMedAllt">
//                        <FilterBox changeEvent={this.filterTextChange} />
//                        <FilterList
//                            data={this.state.lista}
//                            filter={this.state.filterText}
//                            delClick={this.delClick}
//                            selectedCountryIndex={this.state.selectedCountryIndex}
//                            liClickevent={this.liClickevent}
//                            inputText={this.inputText}
//                            blur={this.blur}
//                        />
//                        <br />
//                        <span className="spanNrElements">antal element i listan: {this.state.lista.length}</span>
//                        <br />
//                    </div>
//                );
//            }

//        }
//    }

//    componentDidMount() {
//        this.timerID = setInterval(
//            () => this.tick(),
//            1000
//        );
//        console.log("api call körs nu ")
//        fetch('https://forverkliga.se/JavaScript/api/simple.php?world=all')
//            .then(function (response) {
//                if (response.status != 200 && response.readyState != 4) {
//                    console("problemos buddy " + response.status)
//                    return;
//                }
//                return response.json()
//                    .then(function (json) {
//                        apiData = json;
//                    })
//                    .catch(function (error) {
//                        console.log("Error with the fetch " + error);
//                    })
//            })
//    }
//    componentWillUnmount() {
//        clearInterval(this.timerID);
//    }
//    tick() {
//        if (this.state.count > 0)
//            this.setState({
//                count: this.state.count - 1
//            });
//        else {
//            this.componentWillUnmount();
//            if (typeof apiData !== 'undefined') {
//                apiData.forEach(element => {
//                    landList.push(element.name + "   Folkmängd:  " + element.population)
//                });
//            }
//            else {
//                this.setState({
//                    error: "there is a problem"
//                });
//            }
//            this.setState({
//                lista: landList
//            });
//        }
//    }
//}
//class FilterBox extends React.Component {
//    render() {
//        return (<label className="labelfilter">Filter&nbsp;&nbsp;<input className="inputfilter" onChange={this.props.changeEvent} placeholder="Sök här" /></label>);
//    }
//}
//class FilterList extends React.Component {
//    handleClick(index, x, event) {
//        this.props.liClickevent(index);
//    }
//    render() {
//        const filterLC = this.props.filter.toLowerCase();
//        const newList = this.props.data.filter(
//            x => x.toLowerCase().includes(filterLC)
//        ).map(

//            (x, index) =>
//                <div key={index} onMouseLeave={this.props.blur} className="liLand">
//                    <li
//                        onMouseEnter={this.handleClick.bind(this, index, { x })}

//                    >{x}
//                    </li>
//                    <button className={'btn btn-danger ' + (this.props.selectedCountryIndex === index ? '' : 'hidden')}
//                        onClick={this.props.delClick}
//                    >
//                        Ta bort
//                   </button>
//                    <label className={(this.props.selectedCountryIndex === index ? '' : 'hidden')}> &nbsp; Eller ändra direkt i rutan åvanför &nbsp;
//                          <input className={'inputhidden ' + (this.props.selectedCountryIndex === index ? '' : 'hidden')}
//                            onChange={this.props.inputText} type="text" value={x}
//                        /></label>
//                </div>
//            );

//        return (
//            <ul >
//                {newList}
//            </ul>
//        );
//    }
//}
//ReactDOM.render(
//    <App />,
//    document.getElementById('app')
//);

