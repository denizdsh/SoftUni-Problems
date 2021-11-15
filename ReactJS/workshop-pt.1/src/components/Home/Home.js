import { useEffect, useState } from "react";
import { getLatest } from "../../services/gameService";
import LatestGameCard from "./LatestGameCard";

export default function Home({ viewHandler }) {
    const [games, setGames] = useState([]);

    useEffect(async () => {
        setGames(await getLatest())
    }, [])

    return (
        <section id="welcome-world">

            <div className="welcome-message">
                <h2>ALL new games are</h2>
                <h3>Only in GamesPlay</h3>
            </div>
            <img src="./images/four_slider_img01.png" alt="hero" />

            <div id="home-page">
                <h1>Latest Games</h1>

                {games.map(x => <LatestGameCard key={x._id} game={x} viewHandler={viewHandler} />)
                    || <p className="no-articles">No games yet</p>}

            </div>
        </section>
    );
}